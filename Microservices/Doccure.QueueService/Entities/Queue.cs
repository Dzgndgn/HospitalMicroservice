namespace Doccure.QueueService.Entities
{
    public class Queue
    {
        public int QueueId { get; set; }
        public string PatientName { get; set; }
        public int QueueNumber { get; set; }
        public string BranchName { get; set; }
        public string AppointmentTime { get; set; }
        public string Status { get; set; }
    }
}
