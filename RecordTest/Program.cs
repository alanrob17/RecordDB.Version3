using RecordDAL.Data;
using RecordDAL.Models;
using RecordDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTest
{
    public class Program
    {
        private static readonly ArtistRepository _ar;

        static Program()
        {
            var db = new DataAccess();
            _ar = new ArtistRepository(db);
        }

        public static async Task Main(string[] args)
        {
            // await GetArtistsAsync();
            // await GetArtists();
            // await GetArtistListAsync();
            // await ShowArtistsAsync();
            // await SelectAsync();
            // await GetArtistNamesAsync();
            // await GetSingleArtistAsync(114);
            // await SelectArtistWithNoBioAsync();
            // await InsertAsync();
            // await Insert2Async();
            // await UpdateArtistAsync();
            // await UpdateArtist2Async();
            // await GetArtistIdAsync();
            // await GetArtistId2Async();
            // await UpdateAsync();
            // await Update2Async();
            // await DeleteArtistAsync();
            // await ShowArtistAsync();
            // await GetBiographyAsync();

        }

        private static async Task GetBiographyAsync()
        {
            var recordId = 283;
            var artistId = await _ar.GetArtistIdAsync(recordId);
            var artist = await _ar.SelectAsync(artistId);

            Console.WriteLine(artist.Biography);
        }

        private static async Task ShowArtistAsync()
        {
            var artistId = 114;
            Artist artist = await _ar.SelectAsync(artistId);

            Console.WriteLine(artist.ToString());
        }


        private static async Task DeleteArtistAsync()
        {
            var artistId = 906;
            await _ar.DeleteAsync(artistId);

            Console.WriteLine("Artist deleted");
        }

        private static async Task Update2Async()
        {
            var artistId = 906;
            var firstName = "Alan";
            var lastName = "Robson";
            var name = "Alan Robson";
            var biography = "<p>Alan plays a fast Polka dance music and has had success in Sweden and other Scandinavian countries.</p>";

            artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }


        private static async Task GetArtistId2Async()
        {
            var recordId = 289;
            var artistId = await _ar.GetArtistIdAsync(recordId);

            Console.WriteLine(artistId);
        }

        private static async Task GetArtistIdAsync()
        {
            var artistId = await _ar.GetArtistIdAsync("Bob", "Dylan");

            Console.WriteLine(artistId);
        }

        public static async Task UpdateArtist2Async()
        {
            var artistId = 906;
            var firstName = "Chuck";
            var lastName = "Robson-Smith";
            var name = "Chuck Robson-Smith";
            var biography = "<p>Chuck is a superstar Pop singer.</p>";

            artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }

        private static async Task UpdateArtistAsync()
        {
            var artist = new Artist
            {
                ArtistId = 906,
                FirstName = "Alan",
                LastName = "Robsano",
                Name = "Alan Robsano",
                Biography = "Alan hates country and western. He hates both kinds of music."
            };

            var artistId = await _ar.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        private static async Task UpdateAsync()
        {
            var artist = new Artist
            {
                ArtistId = 906,
                FirstName = "Jamo",
                LastName = "Robsono",
                Name = "Jamo Robsano",
                Biography = "<p>Jamo hates country and western. He hates both kinds of music.</p>"
            };

            var artistId = await _ar.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        public static async Task Insert2Async()
        {
            var artistId = 0;
            var firstName = "James";
            var lastName = "Robson";
            var biography = "James likes Pocopunk.";

            var newArtistId = await _ar.InsertAsync(artistId, firstName, lastName, biography);

            Console.WriteLine(newArtistId);
        }

        public static async Task InsertAsync()
        {
            var artist = new Artist
            {
                ArtistId = 0,
                FirstName = "James",
                LastName = "Robson",
                Biography = "<p>James is an awesome Bass player.</p>"
            };

            var artistId = await _ar.InsertAsync(artist);

            Console.WriteLine(artistId);
        }

        private static async Task SelectArtistWithNoBioAsync()
        {
            var artists = await _ar.SelectArtistWithNoBioAsync();

            foreach (var artist in artists) Console.WriteLine($"{artist.ArtistId}: {artist.Name}");
        }

        private static async Task GetSingleArtistAsync(int artistId)
        {
            var artist = await _ar.SelectAsync(artistId);

            Console.WriteLine($"{artist.ArtistId}: {artist.Name} -- {artist.LastName}, {artist.FirstName}\n{artist.Biography}\n");
        }

        private static async Task GetArtistNamesAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists) Console.WriteLine(artist.Name);
        }

        private static async Task SelectAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists)
            {
                var bio = string.IsNullOrEmpty(artist.Biography) ? "No Biography" : (artist.Biography.Length > 60 ? artist.Biography.Substring(0, 60) + "..." : artist.Biography);
                Console.WriteLine("{0} -- {1}\n{2}\n", artist.ArtistId, artist.Name, bio);
            }
        }

        private static async Task GetArtistsAsync()
        {

            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        private static async Task ShowArtistsAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        // used for ObjectDataSource
        private static async Task GetArtists()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        private static async Task GetArtistListAsync()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

    }
}
