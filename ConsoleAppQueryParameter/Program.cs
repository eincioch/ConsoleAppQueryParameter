// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using System.Web;

// Objeto plano
var parametros = new
{
    Nombre = "Enrique David",
    Apellido = "Incio Chapilliquen",
    Edad = 30,
    Email ="enrique.incio@gmail.com"
};

// Crear query parameters a partir del objeto plano
var queryParametros = HttpUtility.ParseQueryString(string.Empty);

foreach (var propiedad in parametros.GetType().GetProperties())
{
    queryParametros[propiedad.Name] = propiedad.GetValue(parametros)?.ToString();
}

// Obtener la cadena de consulta
var queryString = queryParametros.ToString();

// Utilizar la cadena de consulta en una URL
var url = "https://ejemplo.com/api?" + queryString;

// Imprimir la URL resultante
Console.WriteLine(url);

var queryStringUrl = new System.Uri(url).Query;
var queryParameters = System.Web.HttpUtility.ParseQueryString(queryStringUrl);

// Crear un objeto anónimo con los valores de los parámetros
var jsonObject = new
{
    Nombre = queryParameters["Nombre"],
    Apellido = queryParameters["Apellido"],
    Edad = queryParameters["Edad"],
    Email = queryParameters["Email"]
};

// Convertir el objeto a JSON
string json = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

// Imprimir el JSON resultante
Console.WriteLine(json);

Console.WriteLine("Hello, World!");
