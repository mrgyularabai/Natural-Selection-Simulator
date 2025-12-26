# Natural Selection Simulator (Evolution Simulator)

A C# WPF evolution simulator that demonstrates how a population of species can evolve over time.

The simulation consists of two entity types: **plants** (food) and **animals** (agents).

Each animal is visualized as a red circle with a vision radius that reveals nearby food.

- **Vision radius** – determines how far the animal can see food.
- **Energy level** – consumed each day based on the animal’s radius, speed, and size.
- **Speed** – how far the animal moves per tick.

## How It Works

1. **Daily Tick** – Each day the simulation updates all animals. They move, consume energy, and search for food within their vision radius.
2. **Energy Consumption** – Energy used each day is based on the animal’s vision radius, speed, and size.
3. **Survival** –
   - If an animal cannot find food before its energy reaches zero, it dies.
   - Finding **1 unit of food** allows the animal to survive to the next day.
   - Finding **2 or more units of food** triggers reproduction.
4. **Reproduction** – Offspring receive the parent’s traits with random modifications, enabling evolution over multiple days.

The simulation can be configured to run for a specified number of days, allowing observation of population dynamics and evolutionary trends over time.

## Project Structure

```
├─ LinearAlgebraDotNet/          # Linear algebra utilities (vectors, points)
├─ MovementLab/                  # WPF UI for the movement lab (demo)
├─ NatrualSelectionSim/          # Core simulation
│   ├─ Animal/                   # Player entity implementation
│   ├─ Plant/                    # Food entities
│   ├─ Trait/                    # Trait & mutation logic
│   ├─ World/                    # World management & tick handling
│   └─ GFX/                      # Graphics components
└─ *.sln, *.csproj               # Visual Studio solution & project files
```

## Building & Running

1. **Prerequisites**  
   - Windows 11 (or later)  
   - Visual Studio 2022 with .NET desktop development workload  

2. **Open the Solution**  
   Open `NatrualSelectionSim.sln` in Visual Studio.

3. **Build**  
   Press **Ctrl + Shift + B** or select **Build → Build Solution**.

4. **Run**  
   Press **F5** (Debug) or **Ctrl + F5** (Run without debugging).  
   The main window will display the island, player entities (red circles), and food items (green). Use the UI controls to adjust simulation speed, vision radius, etc.

## Configuration

Key simulation parameters can be tweaked in `NatrualSelectionSim/App.config` or via the UI:

- `InitialEnergy` – Starting energy for each player.  
- `VisionRadius` – Default radius of the vision circle.  
- `MutationRate` – Probability of trait mutation during reproduction.  

## Contributing

Feel free to fork the repository and submit pull requests. Typical contributions include:

- Improving the AI for food searching.  
- Adding new traits or mutation strategies.  
- Enhancing the UI/visualization.  

Please ensure code builds and passes any existing unit tests before submitting.

## License

This project is licensed under the MIT License – see the `LICENSE` file for details.

---

*Natural Selection Simulator* demonstrates emergent behavior and evolutionary dynamics in a simple, visual environment. Enjoy experimenting with different parameters and watching evolution unfold!  
