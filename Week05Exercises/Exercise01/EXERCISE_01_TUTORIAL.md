# Exercise 01 Week 5 - HTTP API Integration Tutorial

## 📋 Exercise Overview
This exercise demonstrates how to integrate with external HTTP APIs using C#. We'll work with the JSONPlaceholder API (https://jsonplaceholder.typicode.com/) to fetch, create, and manage posts and comments.

## 🎯 Learning Objectives
- Understand HTTP client usage in C#
- Work with JSON serialization/deserialization
- Implement async/await patterns
- Apply Repository and Service patterns with HTTP APIs
- Handle external API responses

## 🏗️ Architecture Overview

```
Exercise 01 Structure:
├── Program.cs                    # Main application with API calls
├── Models/
│   ├── Post.cs                  # Post entity with JSON mapping
│   └── Comment.cs               # Comment entity with JSON mapping
├── Repository/
│   ├── IPostRepository.cs       # Repository interface
│   └── PostRepository.cs        # HTTP API repository implementation
├── Service/
│   ├── ITodoApplicationService.cs # Service interface
│   └── TodoApplicationService.cs  # Service implementation
├── Usings.cs                    # Global using statements
└── Global.cs                    # Application constants
```

## 🔧 Step-by-Step Implementation

### Step 1: Set Up Project Structure and Dependencies

**NuGet Package**: Newtonsoft.Json
- **Why?** For JSON serialization/deserialization when working with HTTP APIs
- **Purpose**: Convert C# objects to JSON (for sending to API) and JSON responses to C# objects

**Global.cs**:
```csharp
public class Global
{
    public const string BASE_URL = "https://jsonplaceholder.typicode.com";
}
```

### Step 2: Create Models with JSON Mapping

**Post.cs**:
```csharp
public class Post
{
    [JsonProperty("userId")]
    public int UserId { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }
}
```

**Comment.cs**:
```csharp
public class Comment
{
    [JsonProperty("postId")]
    public int PostId { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string email { get; set; }

    [JsonProperty("Body")]
    public string Body { get; set; }
}
```

## 🤔 How We Decided on the Comment Class Structure

### **Step 1: API Exploration**
1. **Visited the API**: https://jsonplaceholder.typicode.com/
2. **Found the comments endpoint**: `/posts/{id}/comments`
3. **Made a test request**: GET https://jsonplaceholder.typicode.com/posts/1/comments

### **Step 2: Analyzed the JSON Response**
```json
[
  {
    "postId": 1,
    "id": 1,
    "name": "id labore ex et quam laborum",
    "email": "Eliseo@gardner.biz",
    "body": "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium"
  }
]
```

### **Step 3: Mapped JSON to C# Properties**
- **postId** → `int PostId` (which post this comment belongs to)
- **id** → `int Id` (unique comment identifier)
- **name** → `string Name` (commenter's name)
- **email** → `string email` (commenter's email)
- **body** → `string Body` (comment content)

### **Step 4: Added JSON Attributes**
Used `[JsonProperty("propertyName")]` to map C# property names to JSON field names.

## 🔧 Repository Implementation

### **HTTP Client Setup**
```csharp
public class PostRepository : IPostRepository
{
    private readonly HttpClient _httpClient;

    public PostRepository()
    {
        _httpClient = new HttpClient();
    }
}
```

### **GET Request Pattern**
```csharp
public async Task<List<Post>> GetPosts()
{
    // 1. Make HTTP GET request
    var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts");
    
    // 2. Deserialize JSON to C# objects
    return JsonConvert.DeserializeObject<List<Post>>(response)!;
}
```

### **POST Request Pattern**
```csharp
public async Task<Post> AddPost(Post post)
{
    // 1. Serialize C# object to JSON
    var jsonContent = JsonConvert.SerializeObject(post);
    
    // 2. Create HTTP content
    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
    
    // 3. Make HTTP POST request
    var response = await _httpClient.PostAsync($"{Global.BASE_URL}/posts", content);
    
    // 4. Deserialize response to C# object
    return JsonConvert.DeserializeObject<Post>(await response.Content.ReadAsStringAsync())!;
}
```

## 🚀 Key Concepts Explained

### **1. Async/Await Pattern**
```csharp
public async Task<List<Post>> GetPosts()
{
    var response = await _httpClient.GetStringAsync(url);
    return JsonConvert.DeserializeObject<List<Post>>(response)!;
}
```
- **Why async?** HTTP requests are slow operations
- **Why await?** Don't block the thread while waiting for response
- **Task<T>**: Represents an asynchronous operation that returns T

### **2. JSON Serialization**
```csharp
[JsonProperty("userId")]
public int UserId { get; set; }
```
- **JsonProperty**: Maps C# property to JSON field name
- **Serialization**: C# object → JSON string (for sending to API)
- **Deserialization**: JSON string → C# object (for receiving from API)

### **3. HTTP Client Usage**
```csharp
var _httpClient = new HttpClient();
var response = await _httpClient.GetStringAsync(url);
```
- **HttpClient**: .NET's HTTP client for making web requests
- **GetStringAsync**: Makes GET request and returns response as string
- **PostAsync**: Makes POST request with content

### **4. Repository Pattern with HTTP**
```csharp
public interface IPostRepository
{
    Task<List<Post>> GetPosts();
    Task<Post> GetPostById(int id);
    Task<Post> AddPost(Post post);
    Task<List<Comment>> GetCommentsForPost(int id);
}
```
- **Interface**: Defines contract for data access
- **Implementation**: Uses HTTP client instead of database
- **Async methods**: All HTTP operations are asynchronous

## 📊 API Endpoints Used

| Method | Endpoint | Purpose |
|--------|----------|---------|
| GET | `/posts` | Get all posts |
| GET | `/posts/{id}` | Get specific post |
| POST | `/posts` | Create new post |
| GET | `/posts/{id}/comments` | Get comments for post |

## 🔍 Common Patterns

### **1. HTTP Request Pattern**
```csharp
// 1. Make request
var response = await _httpClient.GetStringAsync(url);

// 2. Deserialize response
var result = JsonConvert.DeserializeObject<T>(response)!;

// 3. Return result
return result;
```

### **2. Error Handling**
```csharp
try
{
    var response = await _httpClient.GetStringAsync(url);
    return JsonConvert.DeserializeObject<T>(response)!;
}
catch (HttpRequestException ex)
{
    // Handle network errors
    throw new Exception("Failed to connect to API", ex);
}
catch (JsonException ex)
{
    // Handle JSON parsing errors
    throw new Exception("Invalid JSON response", ex);
}
```

### **3. Service Layer Pattern**
```csharp
public class TodoApplicationService : ITodoApplicationService
{
    private readonly IPostRepository _postRepository;

    public TodoApplicationService()
    {
        _postRepository = new PostRepository();
    }

    public async Task<List<Post>> GetPosts()
    {
        return await _postRepository.GetPosts();
    }
}
```

## 🎯 Exercise Summary

### **What We Built**
1. **HTTP API Integration**: Connected to external JSONPlaceholder API
2. **JSON Serialization**: Used Newtonsoft.Json for data conversion
3. **Async Operations**: Implemented async/await for HTTP requests
4. **Repository Pattern**: Abstracted HTTP operations behind interface
5. **Service Layer**: Added business logic layer

### **Key Learnings**
- **HTTP Client**: How to make web requests in C#
- **JSON Mapping**: How to map JSON to C# objects
- **Async Programming**: How to handle asynchronous operations
- **API Integration**: How to work with external REST APIs
- **Error Handling**: How to handle network and parsing errors

### **Real-World Applications**
- **Web Applications**: Frontend-backend communication
- **Microservices**: Service-to-service communication
- **Third-party APIs**: Integration with external services
- **Mobile Apps**: API communication from mobile clients

This exercise provides a solid foundation for working with HTTP APIs in C# applications!
