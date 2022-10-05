using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UnoRepros;

[INotifyPropertyChanged]
public partial class MainViewModel
{
	[ObservableProperty]
	string text = FA.Play;

	bool switchText;

	[RelayCommand]
	void ChangeText()
	{
		Text = switchText ? FA.Play : FA.Pause;
		switchText = !switchText;
	}
}


public static class FA
{
	public static string Play = "\uf04b";
	public static string Pause = "\uf04c";
}
