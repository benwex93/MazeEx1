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
        List<ISolution> solutionsList;
        public MazeDataBase()
        {
            mazeList = new List<Maze>();
            solutionsList = new List<ISolution>();
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
        public ISolution RetrieveMazeSolution(string name, int solutionType)
        {
            try
            {
                //if file exists
                string jsonString = File.ReadAllText("MazeDatabase.json");
                if (jsonString == "")
                    return null;
                JavaScriptSerializer ser = new JavaScriptSerializer();
                solutionsList = ser.Deserialize<List<ISolution>>(jsonString);
            }
            catch (Exception exc)
            {
                FileStream fs = new FileStream("MazeDatabase.json", FileMode.OpenOrCreate);
                //no solutions yet
                return null;
            }
            foreach (ISolution maze in solutionsList)
            {
                if (maze.name == name && maze.solutionType == solutionType)
                    return maze;
            }
            //doesn't have that particular solution
            return null;
        }
        public void SaveSolToFile(ISolution solution)
        {
            solutionsList.Add(solution);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            String mazeData = ser.Serialize(solutionsList);
            File.WriteAllText("MazeDatabase.json", mazeData);
        }
    }
}
