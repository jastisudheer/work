using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentRepo
{
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment> GetAppointmentByIdAsync(int id);
    Task<bool> InsertAppointmentAsync(Appointment appointment);
    Task<bool> UpdateAppointmentAsync(Appointment appointment);
    Task<bool> DeleteAppointmentAsync(int id);
    Task<bool> CreateAppointmentAsync(Appointment appointment);
}