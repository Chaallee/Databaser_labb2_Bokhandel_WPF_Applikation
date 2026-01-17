using Bokhandel_WPF_Applikation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bokhandel_WPF_Applikation.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly BokhandelContext _context;

    public ObservableCollection<Lagersaldo> StockItems { get; } = new();
    public ObservableCollection<Butiker> Stores { get; } = new();
    public ObservableCollection<Böcker> Books { get; } = new();

    private Butiker? _selectedStore;
    public Butiker? SelectedStore
    {
        get => _selectedStore;
        set => SetProperty(ref _selectedStore, value);
    }

    private Böcker? _selectedBook;
    public Böcker? SelectedBook
    {
        get => _selectedBook;
        set => SetProperty(ref _selectedBook, value);
    }

    private int _quantity = 1;
    public int Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public ICommand AddCommand { get; }
    public ICommand RefreshCommand { get; }
    public ICommand RemoveCommand { get; }

    public ICommand ExitCommand { get; }

    public MainWindowViewModel(BokhandelContext context)
    {
        _context = context;

        RefreshCommand = new RelayCommand(LoadAsync);
        AddCommand = new RelayCommand(AddAsync);
        RemoveCommand = new RelayCommand(RemoveAsync);

        ExitCommand = new RelayCommand(() => 
        {
            Application.Current.Shutdown();
            return Task.CompletedTask;
        });



        _ = LoadAsync();
    }

    private async Task LoadAsync()
    {
        StockItems.Clear();
        Stores.Clear();
        Books.Clear();

        foreach (var s in await _context.Butikers.ToListAsync())
            Stores.Add(s);

        foreach (var b in await _context.Böckers.ToListAsync())
            Books.Add(b);

        var stock = await _context.Lagersaldos
            .Include(l => l.Butiks)
            .Include(l => l.Isbn13Navigation)
                .ThenInclude(b => b.Författare)
            .ToListAsync();


        foreach (var l in stock)
            StockItems.Add(l);
    }

    private async Task AddAsync()
    {
        if (SelectedStore == null || SelectedBook == null || Quantity <= 0)
            return;

        var item = await _context.Lagersaldos
            .FirstOrDefaultAsync(l =>
                l.ButiksId == SelectedStore.ButikId &&
                l.Isbn13 == SelectedBook.Isbn13);

        if (item == null)
        {
            item = new Lagersaldo
            {
                ButiksId = SelectedStore.ButikId,
                Isbn13 = SelectedBook.Isbn13,
                Antal = Quantity
            };

            _context.Lagersaldos.Add(item);
        }
        else
        {
            item.Antal += Quantity;
        }

        await _context.SaveChangesAsync();
        await LoadAsync();
    }

    private async Task RemoveAsync()
    {
        if (SelectedStore == null || SelectedBook == null || Quantity <= 0)
            return;

        var item = await _context.Lagersaldos
            .FirstOrDefaultAsync(l =>
                l.ButiksId == SelectedStore.ButikId &&
                l.Isbn13 == SelectedBook.Isbn13);

        if (item == null)
            return;

        item.Antal -= Quantity;

        if (item.Antal <= 0)
            _context.Lagersaldos.Remove(item);

        await _context.SaveChangesAsync();
        await LoadAsync();
    }
}