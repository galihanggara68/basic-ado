namespace FirstApp
{
  class Program
      {
          static void Main(string[] args)
          {
              Query query = new Query();
              var employee = query.GetOne(101);

              Console.WriteLine("{0} {1} {2}", employee["employee_id"], employee["first_name"], employee["last_name"]);

              //foreach(var employee in employees)
              //{
              //    Console.WriteLine("{0} {1} {2}", employee["employee_id"], employee["first_name"], employee["last_name"]);
              //}

              Console.ReadKey();
          }
      }
    }
