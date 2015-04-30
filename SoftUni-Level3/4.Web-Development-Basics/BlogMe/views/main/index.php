<?php
if (isset( $_GET['msg'] ) )
{
    echo '<div class="success_message">' . base64_decode(urldecode($_GET['msg'])) . '</div>';
}
?>

<h2>This is the project's index file</h2>