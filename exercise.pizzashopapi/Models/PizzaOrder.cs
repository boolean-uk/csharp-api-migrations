using exercise.pizzashopapi.Enums;
using System.Timers;

namespace exercise.pizzashopapi.Models
{
    public class PizzaOrder
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public event EventHandler NextEvent;

        private System.Timers.Timer PreparationTimer;
        private System.Timers.Timer CookingTimer;
        private OrderStatus _status { get; set; } = OrderStatus.Ordered;
        public DateTime EstimatedDelivery { get; set; }

        private void OnPreparingDone(object source, ElapsedEventArgs e)
        {
            PreparationTimer.Dispose();
            NextEvent?.Invoke(this, e);
        }

        private void OnCookingDone(object source, ElapsedEventArgs e)
        {
            CookingTimer.Dispose();
            _status = OrderStatus.Delivering;
            NextEvent?.Invoke(this, e);
        }

        public void StartPreparing()
        {
            PreparationTimer = new System.Timers.Timer(TimeSpan.FromMinutes(1));
            PreparationTimer.Elapsed += OnPreparingDone;
            PreparationTimer.AutoReset = false;
            _status = OrderStatus.Preparing;
            PreparationTimer.Start();
        }

        public void StartCooking()
        {
            CookingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(2));
            CookingTimer.Elapsed += OnCookingDone;
            CookingTimer.AutoReset = false;
            _status = OrderStatus.Cooking;
            CookingTimer.Start();
        }

        public OrderStatus Status { get { return _status; } }
    }
}
