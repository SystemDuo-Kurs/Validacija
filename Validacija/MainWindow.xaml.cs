using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Validacija
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Polaznik();
		}

		private void Sdf(object sender, RoutedEventArgs e)
		{
			var validator = new PolaznikValidator();
			var rez = validator.Validate(DataContext as Polaznik);
			if (!rez.IsValid)
				foreach (var greska in rez.Errors)
					MessageBox.Show($"{greska.PropertyName} -- {greska.ErrorMessage}");
		}
	}
}
