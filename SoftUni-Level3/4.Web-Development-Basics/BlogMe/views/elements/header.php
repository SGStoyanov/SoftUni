<!DOCTYPE html>
<html>
    <head lang="en">
        <meta charset="UTF-8">
        <title>BlogMe</title>
    </head>
    <body>
        <div class="container">
            <div id="top-menu">
                Top menu
            </div>
            <br />
            <?php
                //pr($_SESSION);
                //pr($this -> logged_user);
                if( ! empty ( $this -> logged_user ) ) {
                    echo "<div id='userbar'>Logged user: " . $this -> logged_user['username'] . "</div>";
                }
            ?>
            <br />
            <div id="main">