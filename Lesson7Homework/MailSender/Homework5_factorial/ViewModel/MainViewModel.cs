using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Homework5_factorial.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        int _num;

        public int Number
        {
            get => _num;

            set
            {
                Set<int>(ref _num, value);
            }
        }

        int _result;

        public int Result
        {
            get => _result;

            set
            {
                Set<int>(ref _result, value);
            }
        }

        public RelayCommand<int> CalculateFactorial { get; }


        public MainViewModel()
        {

            CalculateFactorial = new RelayCommand<int>(Calc);

        }

        private void Calc( int num)
        {
            Result = Factorial.Calculate(num);
        }
    }
}