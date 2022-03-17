using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Text.RegularExpressions;
using System.IO;


namespace AvaloniaApplication3.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		string InputText = "";
		string OutputText = "";
		string Regex = "";
		public string MyRegex
		{
			get => Regex;
			set
			{
				if (value != null)
					Regex = value;
			}
		}

		public string Output
		{
			get => OutputText;
			set
			{
				if (MyRegex == "")
					this.RaiseAndSetIfChanged(ref OutputText, "Error");
				else
					this.RaiseAndSetIfChanged(ref OutputText, value);
			}
		}

		public string Input
		{
			get => InputText;
			set
			{
				OutputText = "";
				if (MyRegex != "")
				{
					Regex rgx = new Regex(MyRegex);
					foreach (Match match in rgx.Matches(value))
						Output += match.Value + "\n";
					if (Output == "")
						Output = "No matches found!";
				}
				this.RaiseAndSetIfChanged(ref InputText, value);
			}
		}

	}
}
