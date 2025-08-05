Dictionary<string, int> locations = new Dictionary<string, int> { { "KWE.P.0.002", 200 }, { "KWE.P.1.103", 20 }, { "KWE.A.1.103", 60 }, { "KWE.A.1.104", 30 }, { "KWE.A.1.302", 64 }, { "KWE.A.1.301", 64 } };

var classroomCount = DetermineCoronaClassrooms(locations, 30);
PrintclassroomCount(classroomCount);

static List<string> DetermineCoronaClassrooms(Dictionary<string, int> locations,int groupsize)
{ 

    var classroomCount = new List<string>();
    foreach ( var location in locations)
    {
        if (location.Value >= groupsize * 2)
        {
            classroomCount.Add(location.Key);
         }


    }
    classroomCount.Sort();
   return classroomCount;
}


static void PrintclassroomCount(List<string> classroomCount)
{
    Console.WriteLine("Suitable classrooms for a group of 30 students are:");
    foreach (var room in classroomCount)
    {
        Console.WriteLine($"{room}");
    }
}
