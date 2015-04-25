<!DOCTYPE html>
<html>
<head>
    <title>User Area: Game Page</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <header class="login">
        <?php
        session_start();
        if (isset($_SESSION['name'])) : ?>
            <form method="post">
                <label for="number">Number: </label>
                <input type="text" name="number" />
                <input type="submit" name="submitNumber" value="Guess" />
            </form>
            <?php
            $responseMessage = '';
            $secretNumber = $_SESSION['secretNumber'];
            //echo($secretNumber);
            if(isset($_POST['number']) && isset($_POST['submitNumber'])) {
                $number = $_POST['number'];
                if ($number > $secretNumber && $number <= 100 && $number >= 1) {
                    $responseMessage = 'Down';
                } elseif ($number < $secretNumber && $number <= 100 && $number >= 1) {
                    $responseMessage = 'Up';
                } elseif ($number == $secretNumber) {
                    $responseMessage = 'Congratulations, ' . $_SESSION['name'] . ', the secret number is: ' . $number;
                    ?>
                    <br />
                    <a href="logout.php" target="_parent">[Play Again]</a>
                <?php
                } else {
                    $responseMessage = 'Invalid number';
                }
                ?>
                <p><?php echo $responseMessage ?></p>
            <?php
                }
            ?>
            <br />
            <br />
            <div class="logout"><a href="logout.php">[Logout]</a></div>
        <?php else :
            header('Location: index.php');
        endif; ?>
    </header>
</body>
</html>