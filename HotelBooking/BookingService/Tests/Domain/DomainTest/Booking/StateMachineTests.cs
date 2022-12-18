using Domain.Entites;

namespace DomainTest
{
    public class StateMachineTests
    {

        [Fact]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();

            Assert.Equal(Domain.Enuns.Status.Created, booking?.CurrentStatus);
        }

        [Fact]
        public void ShouldSetStatusToPayingForABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Pay);

            Assert.Equal(Domain.Enuns.Status.Paid, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldSetStatusToCanceledForABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Cancel);

            Assert.Equal(Domain.Enuns.Status.Canceled, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldSetStatusToFinishedForABookingWithPaidStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Pay);

            booking.ChangeState(Domain.Enuns.Action.Finish);

            Assert.Equal(Domain.Enuns.Status.Finished, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldSetStatusToRefoundForABookingWithPaidStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Pay);

            booking.ChangeState(Domain.Enuns.Action.Refound);

            Assert.Equal(Domain.Enuns.Status.Refounded, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldSetStatusToReopenForABookingWithCanceledStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Cancel);

            booking.ChangeState(Domain.Enuns.Action.Reopen);

            Assert.Equal(Domain.Enuns.Status.Created, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldNotChangesStatusWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Refound);

            Assert.Equal(Domain.Enuns.Status.Created, booking.CurrentStatus);
        }

        [Fact]
        public void ShouldNotChangesStatusWhenRefoundingAFinishedBooking()
        {
            var booking = new Booking();

            booking.ChangeState(Domain.Enuns.Action.Pay);
            booking.ChangeState(Domain.Enuns.Action.Finish);
            booking.ChangeState(Domain.Enuns.Action.Refound);

            Assert.Equal(Domain.Enuns.Status.Finished, booking.CurrentStatus);
        }

    }
}