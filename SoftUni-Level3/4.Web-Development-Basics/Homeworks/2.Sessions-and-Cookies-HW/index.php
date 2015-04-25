<!DOCTYPE html>
<html>
<head>
    <title>User Area: Main Page</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <header class="login">
        <?php
        if(isset($_POST['name']) && isset($_POST['submit'])):
            $name = $_POST['name'];
            session_start();
            if (!empty($name)) {
                $_SESSION['name'] = $name;
            }

            include 'inputDataGenerator.php';
            GenerateInputParameters();
            header('Location: play.php');
            die;
        else: ?>
            <form method="POST">
                Name: <input type="text" name="name" placeholder="..." />
                <br />
                <br />
                <input type="submit" name="submit" value="Start Game" />
            </form>
        <?php endif; ?>
    </header>
</body>
</html>