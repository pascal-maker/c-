### C# Exercises Collection

A multi-week set of C# console exercises demonstrating core OOP, interfaces, inheritance, repositories/services, file I/O, JSON/HTTP, and simple CLI apps.

### Prerequisites
- .NET SDK 8.0 (or compatible)
- Optional for JSON work: Newtonsoft.Json (added where needed)
- OS: cross-platform (developed on macOS)

### Repo layout
- `week1exercices/`: Intro C# console tasks + homework
- `Week02Exercises/`: Basic OOP models and relationships
- `Week03exercises/`: Inheritance, interfaces, polymorphism
- `Week04Exercises/`: Repositories, services, CSV I/O, custom exceptions, factory
- `Week05Exercises/`: Larger examples with HTTP/JSON and service layers

### How to run any exercise
- Build:
  ```bash
  dotnet build path/to/ExerciseXX/ExerciseXX.csproj
  ```
- Run:
  ```bash
  dotnet run --project path/to/ExerciseXX/ExerciseXX.csproj
  ```

### Common conventions
- **Nullable**: enabled
- **Implicit usings**: enabled
- **Global usings**: via `Usings.cs` when helpful
- **Layering**: Models → Repository → Service → Program
- **Service style**: normal method bodies with `return await ...`

---

### Week 1 — Basics
Folder: `week1exercices/`
- Console I/O, control flow, simple methods
- Run an exercise:
  ```bash
  dotnet run --project week1exercices/Exercise01/Exercise01.csproj
  ```

### Week 2 — Core OOP models
Folder: `Week02Exercises/`
- Classes like `Person`, `Address`, `Album`, etc.
- Relationships and simple logic

### Week 3 — Inheritance & interfaces
Folder: `Week03exercises/`
- Inheritance (e.g., `Animal`/`Dog`, `Vehicle`)
- Interfaces (`IRefuel`), polymorphism

### Week 4 — Repos/Services, CSV, Exceptions, Factory
Folder: `Week04Exercises/`
- CSV data loading (smartphones, students/courses, beers)
- Custom exceptions
- Repository + Service pattern
- Factory pattern (media)

### Week 5 — HTTP/JSON + Application Services
Folder: `Week05Exercises/`

#### Exercise 01 — JSONPlaceholder posts
- Structure:
  - `Model/Post.cs`, `Model/Comment.cs`
  - `Repository/PostRepository.cs` (HttpClient + Newtonsoft.Json)
  - `Service/TodoApplicationService.cs`
  - `Global.cs` with `BASE_URL = https://jsonplaceholder.typicode.com`
  - `Usings.cs` for common imports
- Typical calls: `GetPosts()`, `GetPostById(id)`, `AddPost(post)`, `GetCommentsForPost(id)`
- Run:
  ```bash
  dotnet run --project Week05Exercises/Exercise01/Exercise01.csproj
  ```

#### Exercise 02 — Artists & Concerts (Swagger-driven)
- API (Swagger):
  - GET `/artists` → list of `{ id, name, genre, country, concertIds[] }`
  - GET `/concerts` → list of `{ id, name, genre, country, price, date }`
- Structure:
  - `Model/Artist.cs`, `Model/Concert.cs` — camelCase JSON mapping via `[JsonProperty]`
  - `Repository/ArtistRepository.cs` — fetch artists/concerts; `GetConcertForArtist(id)` filters by `concertIds`
  - `Service/TodoArtistApplicationService.cs` — normal bodies with `return await ...`
  - `URL.cs` — `BASE_URL` is the site root (do NOT include `index.html`)
  - `Program.cs` — menu UI
    - 1: List artists
    - 2: List concerts
    - 3: Enter artist id → prints artist header, then lists that artist’s concerts
    - 4: Exit
- Run:
  ```bash
  dotnet run --project Week05Exercises/Exercise02/Exercise02.csproj
  ```

### Troubleshooting
- 404 on endpoints: ensure `URL.BASE_URL` is the root (no `index.html`); endpoints are `/artists`, `/concerts`.
- Empty fields: ensure `[JsonProperty("...")]` keys match Swagger exactly.
- Add Newtonsoft.Json:
  ```bash
  dotnet add path/to/project.csproj package Newtonsoft.Json --version 13.0.3
  ```
- Nullability warnings: make strings nullable (`string?`) or initialize; lists as `= new();`

### Suggested improvements
- DI for repositories into services
- `HttpClientFactory` in larger apps
- Error handling/logging around HTTP calls
- Unit tests (mock `HttpMessageHandler`)

### Quick commands
```bash
# Build all
dotnet build

# Run week 5 exercise 1
dotnet run --project Week05Exercises/Exercise01/Exercise01.csproj

# Run week 5 exercise 2
dotnet run --project Week05Exercises/Exercise02/Exercise02.csproj
```
