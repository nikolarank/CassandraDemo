using CassandraDemo;
using CassandraDemo.QueryEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CassandraWinFormsS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getHotelButton_Click(object sender, EventArgs e)
        {
            Hotel h = DataProvider.GetHotel("1");

            MessageBox.Show(h.name);
        }

        private void addHotelButton_Click(object sender, EventArgs e)
        {
           
        }

        private void getHotelsButton_Click(object sender, EventArgs e)
        {
            List<Hotel> hotels = DataProvider.GetHotels();

            foreach (Hotel h in hotels)
                MessageBox.Show(h.name);
        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            DataProvider.AddRoom("1", "101");
            DataProvider.AddRoom("1", "102");
        }

        private void getRoomButton_Click(object sender, EventArgs e)
        {
            Room r = DataProvider.GetRoom("1", "101");

            MessageBox.Show(r.type);
        }

        private void getRoomsButton_Click(object sender, EventArgs e)
        {
            List<Room> rooms = DataProvider.GetRooms();

            foreach (Room r in rooms)
                MessageBox.Show(r.type);
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            DataProvider.DeleteRoom("1", "102");
        }

        private void addGuestButton_Click(object sender, EventArgs e)
        {
            DataProvider.AddGuest("0111111111");
        }

        private void getGuestButton_Click(object sender, EventArgs e)
        {
            Guest g = DataProvider.GetGuest("0111111111");

            MessageBox.Show(g.fname + " " + g.lname);
        }

        private void getGuestsButton_Click(object sender, EventArgs e)
        {
            List<Guest> guests = DataProvider.GetGuests();

            foreach (Guest g in guests)
                MessageBox.Show(g.lname + " " + g.fname);
        }

        private void deleteGuestButton_Click(object sender, EventArgs e)
        {
            DataProvider.DeleteGuest("0111111111");
        }

        private void addReservationButton_Click(object sender, EventArgs e)
        {
            DataProvider.AddReservation("1");
            DataProvider.AddReservation("2");
        }

        private void getReservationButton_Click(object sender, EventArgs e)
        {
            Reservation r = DataProvider.GetReservation("1");

            MessageBox.Show(r.name);
        }

        private void getReservationsButton_Click(object sender, EventArgs e)
        {
            List<Reservation> reservations = DataProvider.GetReservations();

            foreach (Reservation r in reservations)
                MessageBox.Show(r.name);
        }

        private void deleteReservationButton_Click(object sender, EventArgs e)
        {
            DataProvider.DeleteReservation("1");
        }

        private void addHotelButton_Click_1(object sender, EventArgs e)
        {
            DataProvider.AddHotel("1");
            DataProvider.AddHotel("2");
        }

        private void getRoomButton_Click_1(object sender, EventArgs e)
        {
            //ffgfsdgsdd adljncljkfasdjfasnl
            //yfutftfktfktff
        }
    }
}
