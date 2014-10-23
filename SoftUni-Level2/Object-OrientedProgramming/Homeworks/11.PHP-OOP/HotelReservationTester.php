<?php


function __autoload($className) {
    include_once("./" . $className . ".class.php");
}

$firstQuest = new Guest("Stoyan", "Petrov", 23556769);
$secondQuest = new Guest("Ivan", "Hinev", 23651446);
$thirdQuest = new Guest("Petar", "Nanev", 89576576);

$firstReservation = new Reservation("29-09-2014", "30-09-2014", $firstQuest);
$secondReservation = new Reservation("21-10-2014", "24-10-2014", $secondQuest);
$thirdReservation = new Reservation("05-10-2014", "06-10-2014", $thirdQuest);


$rooms[322] = new SingleRoom(322, 50);

BookManager::bookRoom($rooms[322], $firstReservation);

$rooms[326] = new SingleRoom(326, 66);

BookManager::bookRoom($rooms[326], $thirdReservation);
BookManager::bookRoom($rooms[305], $secondReservation);

$rooms[452] = new SingleRoom(452, 70);
$rooms[493] = new Bedroom(493, 120);
$rooms[400] = new Bedroom(400, 60);
$rooms[501] = new Apartment(501, 200);
$rooms[522] = new Apartment(522, 300);
$rooms[612] = new Apartment(612, 400);

echo PHP_EOL;
echo "Bedrooms and apartments with a price less or equal to 250.00";
echo PHP_EOL;

$filteredRooms = array_filter($rooms, "getBedroomsAndApartmentsByPrice");

function getBedroomsAndApartmentsByPrice(Room $room)
{
    if (($room instanceof Bedroom) || ($room instanceof Apartment)) {
        if ($room->getPrice() <= 250) {
            return true;
        }
    }
    return false;
}

foreach ($filteredRooms as $room) {
    echo "{$room->getRoomNumber()} - {$room->getRoomType()} - {$room->getPrice()}" . PHP_EOL;
}

echo PHP_EOL . "All rooms with a balcony";
echo PHP_EOL;

$filteredRoomsWithBalcony = array_filter($rooms, "getAllRoomsWithBalcony");

function getAllRoomsWithBalcony(Room $room)
{
    if ($room->hasBalcony()) {
        return true;
    }
    return false;
}

foreach ($filteredRoomsWithBalcony as $room) {
    echo "{$room->getRoomNumber()} - {$room->getRoomType()} - {$room->hasBalcony()}" . PHP_EOL;
}

echo PHP_EOL . "All room numbers of rooms which have a bathtub";
echo PHP_EOL;

$filteredRoomsWithBathtub = array_filter($rooms, "getAllRoomsWithBathtub");
$roomNumbers = array_map("returnRoomNumbers", $filteredRoomsWithBathtub);

function getAllRoomsWithBathtub(Room $room)
{

    if ($room->hasExtra(Extra::BATHTUB)) {
        return true;
    }
    return false;

}

function returnRoomNumbers($room) {
    return $room->getRoomNumber();
}

foreach ($roomNumbers as $roomNumber) {
    echo $roomNumber . PHP_EOL;
}

echo PHP_EOL . "All apartments which are not booked in a given time period";
echo PHP_EOL;

$allApartments = array_filter($rooms, "isApartment");
$allEmptyApartmentsForPeriod = array_filter($allApartments, "isEmpty");

function isApartment($room){
    return $room instanceof Apartment;
}

function isEmpty(Room $room){

    $quest = new Guest("G", "R", 89466466);
    $reservation = new Reservation("15-10-2014", "18-10-2014", $quest);

    try{
        $room->checkForValidReservation($reservation);
        return true;
    } catch (EReservationException $ex ){
        return false;
    }

}

foreach ($allEmptyApartmentsForPeriod as $apartment) {

    echo $apartment->getRoomNumber() . PHP_EOL;

}