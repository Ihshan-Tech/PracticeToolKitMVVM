using PracticeToolKitMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PracticeToolKitMVVM.Services
{
    public class PatientService
    {
        private ObservableCollection<Patient> _patients = new();

        public ObservableCollection<Patient> GetPatients()
        {
            return _patients;
        }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }


        public void DeletePatient(int id)
        {
            // Find patient by Id and remove from collection
            for (int i = 0; i < _patients.Count; i++)
            {
                if (_patients[i].Id == id)
                {
                    _patients.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
