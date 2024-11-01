using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.BLL.Services
{
    internal class ScheduleService
    {

        public ScheduleService()
        {
        }

        public Task<List<Schedule>> GetSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddScheduleAsync(Schedule schedule)
        {
            throw new NotSupportedException();
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotSupportedException();
        }

        public Task DeleteScheduleAsync(Schedule schedule)
        {
            throw new NotSupportedException();
        }
    }
}
