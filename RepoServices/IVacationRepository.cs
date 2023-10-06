﻿using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IVacationRepository
    {
        public List<Vacation> GetVacations();
        public Vacation GetVacation(int id, DateTime date);
        public List<Vacation> GetVacationByEmployee(int id);

        public void InsertVacation(Vacation vacation);
        public void UpdateVacation(int id, Vacation vacation, DateTime date);
        public void DeleteVacation(int id);
        public bool IsVacation(int id, DateTime date);

    }
}
