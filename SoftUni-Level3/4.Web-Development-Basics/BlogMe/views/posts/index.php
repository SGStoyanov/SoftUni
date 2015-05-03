<h2>Hi, I'm the Regular Posts' view.</h2>

<ul>
    <?php
    foreach ($this -> posts as $post) {

        echo "<li>" . htmlspecialchars($post['Id']) . ' - ' . htmlspecialchars($post['Title']) . "</li>";
    }
    ?>
</ul>

<?php include_once '/views/elements/filterbar.php'; ?>