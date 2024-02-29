using prac.Model;
using prac.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepo _appointmentRepo;

    public AppointmentService(IAppointmentRepo appointmentRepo)
    {
        _appointmentRepo = appointmentRepo;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        return await _appointmentRepo.GetAllAppointmentsAsync();
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id)
    {
        return await _appointmentRepo.GetAppointmentByIdAsync(id);
    }

    public async Task<bool> CreateAppointmentAsync(Appointment appointment)
    {
        return await _appointmentRepo.CreateAppointmentAsync(appointment);
    }

    public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
    {
        return await _appointmentRepo.UpdateAppointmentAsync(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        return await _appointmentRepo.DeleteAppointmentAsync(id);
    }
}