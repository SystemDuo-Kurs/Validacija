using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacija
{
	public class Polaznik : INotifyPropertyChanged, IDataErrorInfo
	{
		private string _tekst;
		public string Tekst 
		{
			get => _tekst;
			set
			{
				_tekst = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tekst"));
			}
		}

		private int _broj;
		public int Broj 
		{ 
			get => _broj; 
			set
			{
				_broj = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Broj"));
			}
		}

		public string Error => throw new NotImplementedException();

		private PolaznikValidator _validator = new();

		public string this[string columnName]
		{
			get
			{
				/*switch (columnName)
				{
					case "Tekst":
						if (_tekst is not null && _tekst.Length <= 3)
							return "Premaaalo";
						break;
					case "Broj":
						if (_broj is < 1 or > 10)
							return "Nije ok :/";
							break;
				}*/
				var err = _validator.Validate(this)
					.Errors.Where(greska => greska.PropertyName == columnName)
					.FirstOrDefault();
				if (err is null)
					return string.Empty;
				else
					return err.ErrorMessage;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class PolaznikValidator : AbstractValidator<Polaznik>
	{
		public PolaznikValidator()
		{
			RuleFor(pol => pol.Tekst)
				.NotEmpty().WithMessage("Praaazno :/")
				.MinimumLength(4).WithMessage("Premalo :/");
			RuleFor(pol => pol.Broj)
				.ExclusiveBetween(0, 11).WithMessage("Neeee");
		}
	}
}
