using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoRepros;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
	public int[] Items = new[] { 0, 1, 2, 3, 4, 6, 7, 8, 9 };

	public MainPage()
	{
		this.InitializeComponent();
		DataContext = this;
	}

	void ItemClicked(object sender, ItemClickEventArgs e)
	{
		if (wasLongPress)
		{
			//HACK: workaround to make sure the item will not be selected
			//await Task.Delay(1);
			Console.WriteLine($"From the xaml list: {list.SelectedItem}");
			Console.WriteLine($"From the sender list: {((ListView)sender).SelectedItem}");
			list.SelectedItem = null;
			((ListView)sender).SelectedItem = null;
			wasLongPress = false;
			return;
		}

		Console.WriteLine($"You typed on {e.ClickedItem}");
	}

	bool wasLongPress;

	void OnCellHolding(object sender, HoldingRoutedEventArgs e)
	{
		if (e.HoldingState != Microsoft.UI.Input.HoldingState.Started)
			return;

		Console.WriteLine("Started");
		e.Handled = wasLongPress = true;
	}
}
