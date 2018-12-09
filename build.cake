/*
Example usage:  
$> ./build.sh
$> ./build.sh -threads=100
 */
var target = Argument("target", "Default");
var requestedThreads = Argument<int>("threads", 10);
var URL = "https://localhost:5001/api/values";

#addin "nuget:https://www.nuget.org/api/v2?package=Cake.Http"

Task("Default")
.Does(() => {
   int maxThreads;
   int workerThreads;
   int portThreads;

   System.Threading.ThreadPool.GetMaxThreads(out maxThreads, out portThreads);
   System.Threading.ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
   Information($"Available worker threads: \t{maxThreads} out of {workerThreads}");
   Information($"Requested worker threads: \t{requestedThreads}");
   Information("");
   Information("WebAPI EndPoint:  " + URL);
   Information("");
   Information("----RESULTS----");
   Information("");
   var source = Enumerable.Range(1, requestedThreads);
   var parallelOptions = new ParallelOptions {MaxDegreeOfParallelism = requestedThreads};
    
    Parallel.ForEach(source, parallelOptions, x => 
      {
          var settings = new HttpSettings
        {
            Headers = new Dictionary<string, string>
            {
                { "Code", "72F050D5-392C-41D7-891E-245723EBFCE5" },
            },
            EnsureSuccessStatusCode = true
        };

         try
         {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            string responseBody =  HttpGet(URL, settings);
            var success = responseBody.StartsWith("Work");
            string result = success ? "Success" : "Err";
            sw.Stop();
            Information(result + " --- Time Taken (s):  " + sw.Elapsed.TotalSeconds);
            if (result == "Err")
            {
               Error(responseBody);
            }
         }
         catch (AggregateException exp)
         {
            Information("Error: " +exp.InnerException.Message);
         }
      });
   
});

RunTarget(target);