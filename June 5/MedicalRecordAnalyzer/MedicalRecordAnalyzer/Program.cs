using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MedicalRecordAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!File.Exists("medical_records.txt"))
                {
                    throw new Exception("File 'medical_records.txt' does not exist.");
                }

                var patientRecords = File.ReadAllLines("medical_records.txt");

                Dictionary<string, List<int>> conditions = new Dictionary<string, List<int>>();

                for (int i = 0; i < patientRecords.Length; i += 3)
                {
                    var nameLine = patientRecords[i];
                    var ageLine = patientRecords[i + 1];
                    var conditionLine = patientRecords[i + 2];

                    var age = int.Parse(ageLine.Split(':').Last().Trim());
                    var condition = conditionLine.Split(':').Last().Trim();

                    if (conditions.ContainsKey(condition))
                    {
                        conditions[condition].Add(age);
                    }
                    else
                    {
                        conditions[condition] = new List<int> { age };
                    }
                }

                using (StreamWriter writer = new StreamWriter("analysis_report.txt"))
                {
                    foreach (var condition in conditions)
                    {
                        var averageAge = condition.Value.Average();
                        writer.WriteLine($"Medical Condition: {condition.Key}");
                        writer.WriteLine($"Average Age: {averageAge}");
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}


