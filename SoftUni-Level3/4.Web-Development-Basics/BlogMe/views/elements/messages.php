<?php
if( ! empty($_SESSION['messages']) ) {
    echo 'Hello from messages php';
    echo '<ul>';
    foreach( $_SESSION['messages'] as $message) {
        echo "<li class={$message['type']}>";
            echo htmlspecialchars($message['text']);
        echo "</li>";
    }

    echo '</ul>';
//    unset($_SESSION['messages']);
}
?>