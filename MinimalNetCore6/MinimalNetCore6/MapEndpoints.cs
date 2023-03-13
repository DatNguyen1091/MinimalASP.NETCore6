using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MinimalNetCore6
{   
    public static class MapEndpoints
    {
        public static void MapPostArray(this WebApplication app)
        {
            app.MapPost("Sort/", ([FromBody] ArrayModel model) =>
            {
                var sortedNumber = model.ArrayNumber!.ToArray();
                var id = model.SortType;
                if (id == 0)
                {
                    Array.Sort(sortedNumber);
                }
                else if (id == 1)
                {
                    for (int i = 0; i < sortedNumber.Length; i++)
                    {
                        for (int j = i + 1; j < sortedNumber.Length; j++)
                        {
                            if (sortedNumber[i] < sortedNumber[j])
                            {
                                int temp = sortedNumber[i];
                                sortedNumber[i] = sortedNumber[j];
                                sortedNumber[j] = temp;
                            }
                        }
                    }
                }
                return sortedNumber;
            });         
        }

        public static void MapArray(this WebApplication app)
        {
            List<int> myArray = new List<int>();
            app.MapPost("Arr/", ([FromBody] SetArray model) =>
            {
                var myArr = model.ArrayNumber!.ToArray();
                myArray.AddRange(myArr);
                return myArr;
            });
            app.MapGet("Arr/", () =>
            {   
                return myArray;
            });
        }

    }
}
