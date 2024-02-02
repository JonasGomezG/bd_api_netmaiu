using MauiApp15.Modelo;
using MauiApp15.Plantillas;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp15.Vistas;

public partial class Vista2 : Plantilla

{
	private static ObservableCollection<Jugador> listaJugadores = new ObservableCollection<Jugador>();

    private static int index = 0;

    public Vista2()
	{
		InitializeComponent();
		consultaHTTP();
	}

    public async void consultaHTTP()
    {
        String host = "https://api.sportsdata.io/v3/nba/scores/json/PlayersActiveBasic?key=96abec686d594a69ab55fd8aceeffbf3";
        HttpClient client = new HttpClient();
        String respuesta = await client.GetStringAsync(host);
        JsonDocument jsonDocument = JsonDocument.Parse(respuesta);
        JsonElement root = jsonDocument.RootElement;

        foreach (JsonElement player in root.EnumerateArray())
        {
            string firstName = GetStringProperty(player, "FirstName");
            string lastName = GetStringProperty(player, "LastName");
            int jersey = GetIntProperty(player, "Jersey");
            string team = GetStringProperty(player, "Team");
            int height = GetIntProperty(player, "Height");
            int weight = GetIntProperty(player, "Weight");
            string position = GetStringProperty(player, "Position");
            
            int alturaX = height;
            int pesoX = weight;
            double alturaY = (double)alturaX;
            double pesoY = (double)pesoX;
            double altura = Math.Round(alturaY * 2.54, 0);
            double peso = Math.Round(pesoY / 2.205, 1);

            switch (position) 
            {
                case "PG":
                    position = "Base";
                    break;
                case "SG":
                    position = "Escolta";
                    break;
                case "SF":
                    position = "Alero";
                    break;
                case "PF":
                    position = "Ala-Pivot";
                    break;
                case "C":
                    position = "Pivot";
                    break;
            }

            var jugador = new Jugador
            {
                FirstName = firstName,
                LastName = lastName,
                Jersey = jersey,
                Team = team,
                Weight = peso,
                Height = altura,
                Position = position
            };

            listaJugadores.Add(jugador);
        }
        string GetStringProperty(JsonElement element, string propertyName)
        {
            return element.TryGetProperty(propertyName, out var property) ? property.GetString() : null;
        }

        int GetIntProperty(JsonElement element, string propertyName)
        {
            return element.TryGetProperty(propertyName, out var property) && property.ValueKind == JsonValueKind.Number ? property.GetInt32() : 0;
        }

        listaView.ItemsSource = listaJugadores;


    }

    private void buscador_SearchButtonPressed(object sender, EventArgs e)
    {
        List<Jugador> strings = new List<Jugador>();

        switch (index)
        {
            case 0:
                strings = listaJugadores.Where(cadena => cadena.FirstName.Equals(buscador.Text)).ToList();
                listaView.ItemsSource = strings;
                break;
            case 1:
                strings = listaJugadores.Where(cadena => cadena.LastName.Equals(buscador.Text)).ToList();
                listaView.ItemsSource = strings;
                break;
            case 2:
                strings = listaJugadores.Where(cadena => cadena.Jersey == int.Parse(buscador.Text)).ToList();
                listaView.ItemsSource = strings;
                break;
            case 3:
                strings = listaJugadores.Where(cadena => cadena.Team.Equals(buscador.Text)).ToList();
                listaView.ItemsSource = strings;
                break;
            case 4:
                strings = listaJugadores.Where(cadena => cadena.Position.Equals(buscador.Text)).ToList();
                listaView.ItemsSource = strings;
                break;
        }
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        index = picker.SelectedIndex;
    }
}

