using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using System.Collections;

namespace Hotel.Controllers
{

    public class HomeController : Controller
    {
        Hotel_ReservationsEntities hr = new Hotel_ReservationsEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rooms()
        {
            List<Room> rooms = hr.Rooms.ToList<Room>();
            return View(rooms);
        }
        public ActionResult Residents()
        {
            List<Guest> guests = hr.Guests.ToList();
            return View(guests);
        }
        public ActionResult Reservation_Details(int? roomnumber)
        {
            dynamic dy = new ExpandoObject();
            dy.reservationlist = GetReservation_FromRoom(roomnumber);
            dy.guestlist = GetGuest(roomnumber);
            return View(dy);
        }
        public ActionResult Details(int guestid)
        {
            dynamic dy = new ExpandoObject();
            dy.reservationlist = GetReservation_FromGuest(guestid);
            dy.roomlist = GetRooms(guestid);
            return View(dy);
        }
        [HttpGet]
        public ActionResult Reservation(int? roomnumber)
        {
            ViewBag.roomnumber = roomnumber;
            return View();
        }
        [HttpPost]
        public ActionResult Reservation(int adults , int children , System.DateTime reservationdate
            , System.DateTime checkindate, System.DateTime checkoutdate, decimal total,int? roomnumber)
        {
            Reservation res = new Reservation() { Adults = adults, Children = children
                , ReservationDate = reservationdate , CheckInDate = checkindate , CheckOutDate = checkoutdate
                , Total = total};
            hr.Reservations.Add(res);
            hr.SaveChanges();
            Room r = hr.Rooms.Find(roomnumber);
            r.Reservations = new HashSet<Reservation> { res };
            r.Reserved = true;
            hr.SaveChanges();
            ViewBag.reservationid = res.ReservationId;
            return View("Reservation1");
        }
        public ActionResult Check_Out(int? guestid)
        {
            Guest guest = hr.Guests.Find(guestid);
            List<Reservation> reservation_list = guest.Reservations.ToList();
            Reservation reservation = hr.Reservations.Find(reservation_list[0].ReservationId);
            List<Room> room_list = reservation.Rooms.ToList();
            Room room = hr.Rooms.Find(room_list[0].RoomNumber);
            hr.Guests.Remove(guest);
            hr.Reservations.Remove(reservation);
            room.Reserved = false;
            hr.SaveChanges();
            return RedirectToAction("Residents");
        }
        public ActionResult Guest_reservation(string firstname , string lastname , string address , string phone , int reservationid)
        {
            Guest guest = new Guest() { FirstName = firstname, LastName = lastname, Address = address, Phone = phone };
            hr.Guests.Add(guest);
            hr.SaveChanges();
            Reservation reservation = hr.Reservations.Find(reservationid);
            reservation.Guests = new HashSet<Guest> { guest };
            hr.SaveChanges();
            return RedirectToAction("Rooms");
        }





        public List<Reservation> GetReservation_FromGuest(int? guestid)
        {
            Guest guest = hr.Guests.Find(guestid);
            List<Reservation> reservation_list = guest.Reservations.ToList();
            return reservation_list;
        }
        public List<Room> GetRooms(int? guestid)
        {
            Guest guest = hr.Guests.Find(guestid);
            List<Reservation> reservation_list = guest.Reservations.ToList();
            Reservation reservation = hr.Reservations.Find(reservation_list[0].ReservationId);
            List<Room> room = reservation.Rooms.ToList();
            return room;
        }
        public List<Reservation> GetReservation_FromRoom(int? roomnumber)
        {
            Room room = hr.Rooms.Find(roomnumber);
            List<Reservation> reservation_list = room.Reservations.ToList();
            return reservation_list;
        }
        public List<Guest> GetGuest(int? roomnumber)
        {
            Room room = hr.Rooms.Find(roomnumber);
            List<Reservation> reservation_list = room.Reservations.ToList();
            Reservation reservation = hr.Reservations.Find(reservation_list[0].ReservationId);
            List<Guest> guest = reservation.Guests.ToList();
            return guest;
        }
    }
}