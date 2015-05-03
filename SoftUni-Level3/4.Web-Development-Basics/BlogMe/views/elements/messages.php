<?php
if( isset($_SESSION['messages']) ) {
    echo '<ul>';
    foreach( $_SESSION['messages'] as $message) {
        echo "<li class={$message['type']}>";
            echo htmlspecialchars($message['text']);
        echo "</li>";
    }

    echo '</ul>';
    unset($_SESSION['messages']);
}
?>