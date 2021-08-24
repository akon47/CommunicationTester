using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HexEditor
{
	/// <summary>
	/// HexEditorControl.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class HexEditorControl : UserControl
	{
        //public Brush Foreground
        //{
        //    get => (Brush)GetValue(ForegroundProperty);
        //    set => SetValue(ForegroundProperty, value);
        //}
        //public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
        //    nameof(Foreground), typeof(Brush), typeof(HexEditorControl), new PropertyMetadata(Brushes.Black));

        protected ObservableCollection<byte> Bytes { get; set; }

		public HexEditorControl()
		{
            Bytes = new ObservableCollection<byte>();
			InitializeComponent();
		}

        public void AddByte(byte value)
        {

        }
	}
}
