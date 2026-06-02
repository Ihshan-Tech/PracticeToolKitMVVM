# PracticeToolKitMVVM

Small WPF MVVM sample app demonstrating a simple in-memory patient registry using CommunityToolkit.Mvvm.

- Target framework: .NET 10
- UI: WPF
- MVVM: CommunityToolkit.Mvvm (ObservableObject / RelayCommand / ObservableProperty)
- Purpose: example code for adding, updating and deleting `Patient` items via `PatientService` and `PatientViewModel`.

## Project structure (important files)
- `Models/Patient.cs` — domain model for a patient.
- `Services/PatientService.cs` — in-memory `ObservableCollection<Patient>` service.
- `ViewModels/PatientViewModel.cs` — view model with add/update/delete commands.
- `Views/PatientView.xaml` — UI view (user control) bound to the view model.
- `PracticeToolKitMVVM.csproj` — project file, references CommunityToolkit.Mvvm.

## Prerequisites
- .NET 10 SDK installed: https://dotnet.microsoft.com/
- Visual Studio 2026 (Community/Professional/Enterprise) or another IDE that supports WPF/.NET 10.
- Windows OS for WPF desktop execution.

## Build and run
Using Visual Studio
1. Open the solution in Visual Studio.
2. Restore NuGet packages (Visual Studio will restore automatically).
3. Set the WPF project as startup project.
4. Press F5 to run.

Using dotnet CLI
1. Open a terminal in the repo root (PowerShell preferred).
2. Restore and run:
   - dotnet restore
   - dotnet build
   - dotnet run --project PracticeToolKitMVVM\PracticeToolKitMVVM.csproj

## Notes & limitations
- Data is stored in-memory; restarting the app clears the list.
- `Patient` model is a plain POCO. The view model uses an `ObservableCollection<Patient>` from the service so the UI updates automatically.
- There are no unit tests included. Consider adding tests for `PatientService` and `PatientViewModel` (use MSTest / xUnit / NUnit).

## Suggested improvements
- Persist patients (SQLite, JSON file, or a remote API).
- Add input validation and user-friendly error feedback.
- Add unit/integration tests and CI pipeline.
- Use dependency injection for services (e.g., Microsoft.Extensions.DependencyInjection).

## Contributing
Feel free to open issues or pull requests. Keep changes small and add tests where applicable.

## License
MIT — see LICENSE file (or add one if needed).
