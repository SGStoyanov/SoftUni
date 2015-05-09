<!DOCTYPE html>
<html>
    <head lang="en">
        <meta charset="UTF-8">
        <title>BlogMe</title>
        <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href=<?php echo DX_URL . "content/defaultStyle.css" ?> >
    </head>
    <body>
        <header>
            <!-- Navigation -->
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="container">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="<?php echo DX_URL ?>posts/">BlogMe</a>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <?php if ( ! empty( $this -> logged_user ) ): ?>
                                <li>
                                    <a href="<?php echo DX_URL ?>admin/posts/add">Add Post</a>
                                </li>
                            <?php endif; ?>
                            <li>
                                <a href="#">About</a>
                            </li>
                            <li>
                                <a href="#">Services</a>
                            </li>
                            <li>
                                <a href="#">Contact</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>
            <ul>
                <li><a href="<?php echo DX_URL ?>posts/">Home</a></li>
                <?php if ( ! empty( $this -> logged_user ) ): ?>
                    <li>
                        <a href="<?php echo DX_URL ?>admin/posts/add">Add Post</a>
                    </li>
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