<?php
function GenerateInputParameters()
{
    $secretNumber = rand(1, 100);
    $_SESSION['secretNumber'] = $secretNumber;
}
?>