<?php

require_once "Room.class.php";

class SingleRoom extends Room {

    const BED_COUNT = 1;

    /**
     * @param $roomNumber
     * @param $price
     */
    function __construct($roomNumber, $price)
    {
        parent::__construct($roomNumber, SingleRoom::BED_COUNT, $price, true, false, RoomType::STANDARD);
        $this->addExtras(Extra::TV);
        $this->addExtras(Extra::AIR_CONDITIONER);
    }

}