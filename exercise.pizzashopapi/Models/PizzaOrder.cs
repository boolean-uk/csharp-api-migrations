using exercise.pizzashopapi.Enums;
using System.Timers;

namespace exercise.pizzashopapi.Models
{
    public class PizzaOrder
    {
        public int OrderId { get; set; }
        public event EventHandler NextEvent;

        private System.Timers.Timer PreparationTimer;
        private System.Timers.Timer CookingTimer;
        private PizzaStatus _status { get; set; }
        public DateTime EstimatedFinish { get; set; }

        private void OnPreparingDone(object source, ElapsedEventArgs e)
        {
            PreparationTimer.Dispose();
            NextEvent?.Invoke(source, e);
        }

        private void OnCookingDone(object source, ElapsedEventArgs e)
        {
            CookingTimer.Dispose();
            _status = PizzaStatus.Cooked;
            NextEvent?.Invoke(source, e);
        }

        public void StartPreparing()
        {
            PreparationTimer = new System.Timers.Timer(TimeSpan.FromMinutes(3));
            PreparationTimer.Elapsed += OnPreparingDone;
            PreparationTimer.AutoReset = false;
            _status = PizzaStatus.Preparing;
            PreparationTimer.Start();
        }

        public void StartCooking()
        {
            CookingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(12));
            CookingTimer.Elapsed += OnCookingDone;
            CookingTimer.AutoReset = false;
            _status = PizzaStatus.Cooking;
            CookingTimer.Start();
        }

        public PizzaStatus Status { get { return _status; } }
    }
}
