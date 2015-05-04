<!DOCTYPE html>
<html>
    <head lang="en">
        <meta charset="UTF-8">
        <title>BlogMe</title>
        <link rel="stylesheet" type="text/css" href=<?php echo DX_URL . "content/defaultStyle.css" ?> >
    </head>
    <body>
        <header>
            <ul>
                <li><a href="<?php echo DX_URL ?>posts/">Home</a></li>
                <?php if ( ! empty( $this -> logged_user ) ): ?>
                    <li><a href="<?php echo DX_URL ?>admin/posts/add">Add Post</a></li>
                <?php endif; ?>
                <li><a href="/views/aboutMe/">About</a></li>
                <li id="userbar">
                    <?php
                    if( ! empty( $this -> logged_user ) ): ?>
                        <div>
                            <a href="<?php echo DX_URL ?>admin/users/view/<?php echo $this -> logged_user['id']; ?>">
                            <?php echo $this -> logged_user['username']; ?>
                            </a>
                            <a id="logout-btn" href="<?php echo DX_URL ?>login/logout">Logout</a>
                        </div>
                    <?php else: ?>
                        <div>
                            <a href="<?php echo DX_URL ?>login/">Login</a>
                            <a href="<?php echo DX_URL ?>register/">Register</a>
                        </div>
                    <?php endif; ?>
                </li>
            </ul>
        </header>
        <div class="container">
            <br />
            <div id="main">