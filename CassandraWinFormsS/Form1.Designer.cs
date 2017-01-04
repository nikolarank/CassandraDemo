namespace CassandraWinFormsS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteReservationButton = new System.Windows.Forms.Button();
            this.getReservationsButton = new System.Windows.Forms.Button();
            this.addReservationButton = new System.Windows.Forms.Button();
            this.reservationGroupBox = new System.Windows.Forms.GroupBox();
            this.getReservationButton = new System.Windows.Forms.Button();
            this.getGuestButton = new System.Windows.Forms.Button();
            this.addGuestButton = new System.Windows.Forms.Button();
            this.deleteRoomButton = new System.Windows.Forms.Button();
            this.getRoomsButton = new System.Windows.Forms.Button();
            this.getRoomButton = new System.Windows.Forms.Button();
            this.deleteGuestButton = new System.Windows.Forms.Button();
            this.getGuestsButton = new System.Windows.Forms.Button();
            this.addRoomButton = new System.Windows.Forms.Button();
            this.Room = new System.Windows.Forms.GroupBox();
            this.deleteHotelButton = new System.Windows.Forms.Button();
            this.getHotelsButton = new System.Windows.Forms.Button();
            this.Hotel = new System.Windows.Forms.GroupBox();
            this.getHotelButton = new System.Windows.Forms.Button();
            this.addHotelButton = new System.Windows.Forms.Button();
            this.guestGroupBox = new System.Windows.Forms.GroupBox();
            this.reservationGroupBox.SuspendLayout();
            this.Room.SuspendLayout();
            this.Hotel.SuspendLayout();
            this.guestGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteReservationButton
            // 
            this.deleteReservationButton.Location = new System.Drawing.Point(87, 17);
            this.deleteReservationButton.Name = "deleteReservationButton";
            this.deleteReservationButton.Size = new System.Drawing.Size(75, 23);
            this.deleteReservationButton.TabIndex = 3;
            this.deleteReservationButton.Text = "Delete res";
            this.deleteReservationButton.UseVisualStyleBackColor = true;
            // 
            // getReservationsButton
            // 
            this.getReservationsButton.Location = new System.Drawing.Point(6, 71);
            this.getReservationsButton.Name = "getReservationsButton";
            this.getReservationsButton.Size = new System.Drawing.Size(75, 23);
            this.getReservationsButton.TabIndex = 2;
            this.getReservationsButton.Text = "Get ress";
            this.getReservationsButton.UseVisualStyleBackColor = true;
            // 
            // addReservationButton
            // 
            this.addReservationButton.Location = new System.Drawing.Point(6, 17);
            this.addReservationButton.Name = "addReservationButton";
            this.addReservationButton.Size = new System.Drawing.Size(75, 23);
            this.addReservationButton.TabIndex = 1;
            this.addReservationButton.Text = "Add res";
            this.addReservationButton.UseVisualStyleBackColor = true;
            // 
            // reservationGroupBox
            // 
            this.reservationGroupBox.Controls.Add(this.deleteReservationButton);
            this.reservationGroupBox.Controls.Add(this.getReservationsButton);
            this.reservationGroupBox.Controls.Add(this.getReservationButton);
            this.reservationGroupBox.Controls.Add(this.addReservationButton);
            this.reservationGroupBox.Location = new System.Drawing.Point(297, 157);
            this.reservationGroupBox.Name = "reservationGroupBox";
            this.reservationGroupBox.Size = new System.Drawing.Size(200, 100);
            this.reservationGroupBox.TabIndex = 9;
            this.reservationGroupBox.TabStop = false;
            this.reservationGroupBox.Text = "Reservation";
            // 
            // getReservationButton
            // 
            this.getReservationButton.Location = new System.Drawing.Point(6, 44);
            this.getReservationButton.Name = "getReservationButton";
            this.getReservationButton.Size = new System.Drawing.Size(75, 23);
            this.getReservationButton.TabIndex = 0;
            this.getReservationButton.Text = "Get res";
            this.getReservationButton.UseVisualStyleBackColor = true;
            // 
            // getGuestButton
            // 
            this.getGuestButton.Location = new System.Drawing.Point(6, 44);
            this.getGuestButton.Name = "getGuestButton";
            this.getGuestButton.Size = new System.Drawing.Size(75, 23);
            this.getGuestButton.TabIndex = 0;
            this.getGuestButton.Text = "Get guest";
            this.getGuestButton.UseVisualStyleBackColor = true;
            // 
            // addGuestButton
            // 
            this.addGuestButton.Location = new System.Drawing.Point(6, 17);
            this.addGuestButton.Name = "addGuestButton";
            this.addGuestButton.Size = new System.Drawing.Size(75, 23);
            this.addGuestButton.TabIndex = 1;
            this.addGuestButton.Text = "Add guest";
            this.addGuestButton.UseVisualStyleBackColor = true;
            // 
            // deleteRoomButton
            // 
            this.deleteRoomButton.Location = new System.Drawing.Point(87, 17);
            this.deleteRoomButton.Name = "deleteRoomButton";
            this.deleteRoomButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRoomButton.TabIndex = 3;
            this.deleteRoomButton.Text = "Delete room";
            this.deleteRoomButton.UseVisualStyleBackColor = true;
            // 
            // getRoomsButton
            // 
            this.getRoomsButton.Location = new System.Drawing.Point(6, 71);
            this.getRoomsButton.Name = "getRoomsButton";
            this.getRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.getRoomsButton.TabIndex = 2;
            this.getRoomsButton.Text = "Get rooms";
            this.getRoomsButton.UseVisualStyleBackColor = true;
            // 
            // getRoomButton
            // 
            this.getRoomButton.Location = new System.Drawing.Point(6, 44);
            this.getRoomButton.Name = "getRoomButton";
            this.getRoomButton.Size = new System.Drawing.Size(75, 23);
            this.getRoomButton.TabIndex = 0;
            this.getRoomButton.Text = "Get room";
            this.getRoomButton.UseVisualStyleBackColor = true;
            this.getRoomButton.Click += new System.EventHandler(this.getRoomButton_Click_1);
            // 
            // deleteGuestButton
            // 
            this.deleteGuestButton.Location = new System.Drawing.Point(87, 17);
            this.deleteGuestButton.Name = "deleteGuestButton";
            this.deleteGuestButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGuestButton.TabIndex = 3;
            this.deleteGuestButton.Text = "Delete guest";
            this.deleteGuestButton.UseVisualStyleBackColor = true;
            // 
            // getGuestsButton
            // 
            this.getGuestsButton.Location = new System.Drawing.Point(6, 71);
            this.getGuestsButton.Name = "getGuestsButton";
            this.getGuestsButton.Size = new System.Drawing.Size(75, 23);
            this.getGuestsButton.TabIndex = 2;
            this.getGuestsButton.Text = "Get guests";
            this.getGuestsButton.UseVisualStyleBackColor = true;
            // 
            // addRoomButton
            // 
            this.addRoomButton.Location = new System.Drawing.Point(6, 17);
            this.addRoomButton.Name = "addRoomButton";
            this.addRoomButton.Size = new System.Drawing.Size(75, 23);
            this.addRoomButton.TabIndex = 1;
            this.addRoomButton.Text = "Add room";
            this.addRoomButton.UseVisualStyleBackColor = true;
            // 
            // Room
            // 
            this.Room.Controls.Add(this.deleteRoomButton);
            this.Room.Controls.Add(this.getRoomsButton);
            this.Room.Controls.Add(this.getRoomButton);
            this.Room.Controls.Add(this.addRoomButton);
            this.Room.Location = new System.Drawing.Point(297, 29);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(200, 100);
            this.Room.TabIndex = 7;
            this.Room.TabStop = false;
            this.Room.Text = "Room";
            // 
            // deleteHotelButton
            // 
            this.deleteHotelButton.Location = new System.Drawing.Point(87, 17);
            this.deleteHotelButton.Name = "deleteHotelButton";
            this.deleteHotelButton.Size = new System.Drawing.Size(75, 23);
            this.deleteHotelButton.TabIndex = 3;
            this.deleteHotelButton.Text = "Delete hotel";
            this.deleteHotelButton.UseVisualStyleBackColor = true;
            // 
            // getHotelsButton
            // 
            this.getHotelsButton.Location = new System.Drawing.Point(6, 71);
            this.getHotelsButton.Name = "getHotelsButton";
            this.getHotelsButton.Size = new System.Drawing.Size(75, 23);
            this.getHotelsButton.TabIndex = 2;
            this.getHotelsButton.Text = "Get hotels";
            this.getHotelsButton.UseVisualStyleBackColor = true;
            // 
            // Hotel
            // 
            this.Hotel.Controls.Add(this.deleteHotelButton);
            this.Hotel.Controls.Add(this.getHotelsButton);
            this.Hotel.Controls.Add(this.getHotelButton);
            this.Hotel.Controls.Add(this.addHotelButton);
            this.Hotel.Location = new System.Drawing.Point(67, 29);
            this.Hotel.Name = "Hotel";
            this.Hotel.Size = new System.Drawing.Size(200, 100);
            this.Hotel.TabIndex = 6;
            this.Hotel.TabStop = false;
            this.Hotel.Text = "Hotel";
            // 
            // getHotelButton
            // 
            this.getHotelButton.Location = new System.Drawing.Point(6, 44);
            this.getHotelButton.Name = "getHotelButton";
            this.getHotelButton.Size = new System.Drawing.Size(75, 23);
            this.getHotelButton.TabIndex = 0;
            this.getHotelButton.Text = "Get hotel";
            this.getHotelButton.UseVisualStyleBackColor = true;
            // 
            // addHotelButton
            // 
            this.addHotelButton.Location = new System.Drawing.Point(6, 17);
            this.addHotelButton.Name = "addHotelButton";
            this.addHotelButton.Size = new System.Drawing.Size(75, 23);
            this.addHotelButton.TabIndex = 1;
            this.addHotelButton.Text = "Add hotel";
            this.addHotelButton.UseVisualStyleBackColor = true;
            this.addHotelButton.Click += new System.EventHandler(this.addHotelButton_Click_1);
            // 
            // guestGroupBox
            // 
            this.guestGroupBox.Controls.Add(this.deleteGuestButton);
            this.guestGroupBox.Controls.Add(this.getGuestsButton);
            this.guestGroupBox.Controls.Add(this.getGuestButton);
            this.guestGroupBox.Controls.Add(this.addGuestButton);
            this.guestGroupBox.Location = new System.Drawing.Point(67, 157);
            this.guestGroupBox.Name = "guestGroupBox";
            this.guestGroupBox.Size = new System.Drawing.Size(200, 100);
            this.guestGroupBox.TabIndex = 8;
            this.guestGroupBox.TabStop = false;
            this.guestGroupBox.Text = "Guest";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 293);
            this.Controls.Add(this.reservationGroupBox);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.Hotel);
            this.Controls.Add(this.guestGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.reservationGroupBox.ResumeLayout(false);
            this.Room.ResumeLayout(false);
            this.Hotel.ResumeLayout(false);
            this.guestGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteReservationButton;
        private System.Windows.Forms.Button getReservationsButton;
        private System.Windows.Forms.Button addReservationButton;
        private System.Windows.Forms.GroupBox reservationGroupBox;
        private System.Windows.Forms.Button getReservationButton;
        private System.Windows.Forms.Button getGuestButton;
        private System.Windows.Forms.Button addGuestButton;
        private System.Windows.Forms.Button deleteRoomButton;
        private System.Windows.Forms.Button getRoomsButton;
        private System.Windows.Forms.Button getRoomButton;
        private System.Windows.Forms.Button deleteGuestButton;
        private System.Windows.Forms.Button getGuestsButton;
        private System.Windows.Forms.Button addRoomButton;
        private System.Windows.Forms.GroupBox Room;
        private System.Windows.Forms.Button deleteHotelButton;
        private System.Windows.Forms.Button getHotelsButton;
        private System.Windows.Forms.GroupBox Hotel;
        private System.Windows.Forms.Button getHotelButton;
        private System.Windows.Forms.Button addHotelButton;
        private System.Windows.Forms.GroupBox guestGroupBox;
    }
}

