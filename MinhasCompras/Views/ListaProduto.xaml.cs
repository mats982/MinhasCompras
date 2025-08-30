using System.Collections.ObjectModel;
using Android.Net.Vcn;

namespace MinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> Lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = Lista;
	}

    protected async override void OnAppearing()
    {
        List<Produto> tmp = await App.Db.GetAll();

		tmp.ForEach(i => Lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());

		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}


    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;

		Lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => Lista.Add(i));
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		double soma = Lista.Sum(i => i.Total);

		string msg = $"O rotal � {soma:C}";

		DisplayAlert("Total dos produtos", msg, "OK");
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}