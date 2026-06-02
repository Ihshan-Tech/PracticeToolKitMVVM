using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticeToolKitMVVM.Models;
using PracticeToolKitMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace PracticeToolKitMVVM.ViewModels
{
    public partial class PatientViewModel : ObservableObject
    {
        private readonly Services.PatientService _patientService;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string patientName;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string gender;

        [ObservableProperty]
        private string disease;

        [ObservableProperty]
        private string doctorName;


        [ObservableProperty]
        public partial Patient SelectedPatient { get; set; }

        public ObservableCollection<Patient> Patients { get; set; }

        public PatientViewModel()
        {
            _patientService = new PatientService();
            // use the same collection instance from the service so UI updates reflect service changes
            Patients = _patientService.GetPatients();
        }

        [RelayCommand]
        private void AddPatient()
        {
            if (string.IsNullOrWhiteSpace(PatientName))
            {
                MessageBox.Show("Please enter patient name");
                return;
            }

            var patient = new Patient
            {
                Id = Id,
                PatientName = PatientName,
                Age = Age,
                Gender = Gender,
                Disease = Disease,
                DoctorName = DoctorName
            };

            _patientService.AddPatient(patient);
            ClearForm();
        }

        [RelayCommand]
        private void UpdatePatient()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Please select a patient to update");
                return;
            }

            SelectedPatient.Id = Id;
            SelectedPatient.PatientName = PatientName;
            SelectedPatient.Age = Age;
            SelectedPatient.Gender = Gender;
            SelectedPatient.Disease = Disease;
            SelectedPatient.DoctorName = DoctorName;

            // properties on Patient now raise change notifications (Patient is observable),
            // so no need to notify the collection itself.
            ClearForm();
        }

        [RelayCommand]
        private void DeletePatient()
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Please select a patient to delete");
                return;
            }
            _patientService.DeletePatient(SelectedPatient.Id);
            ClearForm();
        }

        partial void OnSelectedPatientChanged(Patient value)
        {
            if (value != null)
            {
                Id = value.Id;
                PatientName = value.PatientName;
                Age = value.Age;
                Gender = value.Gender;
                Disease = value.Disease;
                DoctorName = value.DoctorName;
            }
        }

        private void ClearForm()
        {
            Id = 0;
            PatientName = string.Empty;
            Age = 0;
            Gender = string.Empty;
            Disease = string.Empty;
            DoctorName = string.Empty;

        }
    }

}