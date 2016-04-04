using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
namespace MazeEx1
{
    class MazeDataBase
    {

        static List<Maze> mazeList;
        static List<SolutionDataClass> solutionsList;
        public MazeDataBase()
        {
            mazeList = new List<Maze>();
            solutionsList = new List<SolutionDataClass>();
        }
        public void AddMaze(Maze mazeToAdd)
        {
            mazeList.Add(mazeToAdd);
        }
        public Maze RetrieveMaze(string name)
        {
            foreach (Maze maze in mazeList)
            {
                if (maze.name == name)
                    return maze;
            }
            //doesn't have that particular maze
            return null;
        }
        public SolutionDataClass RetrieveMazeSolution(string name)
        {
            foreach (SolutionDataClass maze in solutionsList)
            {
                if (maze.Name == name)
                    return maze;
            }
            List<SolutionDataClass> savedSolutions;
            try
            {
                //if file exists
                string jsonString = File.ReadAllText("MazeDatabase.json");
                if (jsonString == "")
                    return null;
                JavaScriptSerializer ser = new JavaScriptSerializer();
                savedSolutions = new List<SolutionDataClass>();
                savedSolutions = ser.Deserialize<List<SolutionDataClass>>(jsonString);
            }
            catch (Exception)
            {
                FileStream fs = new FileStream("MazeDatabase.json", FileMode.OpenOrCreate);
                fs.Close();
                //no solutions yet
                return null;
            }
            if (savedSolutions != null)
                solutionsList.AddRange(savedSolutions);
            foreach (SolutionDataClass sol in savedSolutions)
            {
                if (sol.Name == name)
                    return sol;
            }
            //doesn't have that particular solution
            return null;
        }
        public void SaveSolToFile(ISolution solution)
        {
            solutionsList.Add(solution.ToSolutionDataClass());
            JavaScriptSerializer ser = new JavaScriptSerializer();
            String mazeData = ser.Serialize(solutionsList);
            File.WriteAllText("MazeDatabase.json", mazeData);
        }
    }
}
