<!DOCTYPE html>
<html>
    <head lang="en">
        <meta charset="UTF-8">
        <title>BlogMe</title>
        <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">

        <!-- Custom CSS -->
        <link href="<?php echo DX_URL ?>content/css/blog-post.css" rel="stylesheet">
        <link href="<?php echo DX_URL ?>content/css/personal.css" rel="stylesheet">
    </head>
    <body>
        <header>
            <!-- Navigation -->
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="container">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse"
                                data-target="#bs-example-navbar-collapse-1">
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
                            <li>
                                <a href="<?php echo DX_URL ?>posts/index">Posts</a>
                            </li>
                            <li>
                                <a href="#">About</a>
                            </li>
                            <li>
                                <a href="#">Contact</a>
                            </li>
                            <?php
                            if( ! empty( $this -> logged_user ) ): ?>
                                <li>
                                    <a href="<?php echo DX_URL ?>admin/posts/add">Add Post(Admin)</a>
                                </li>
                                <li>
                                    <a href="<?php echo DX_URL ?>admin/posts/index">Posts(Admin)</a>
                                </li>
                                <li>
                                    <a href="<?php echo DX_URL ?>admin/users/index">Users(Admin)</a>
                                </li>
                                <li>
                                    <a id="users-btn" href="<?php
                                              echo DX_URL ?>admin/users/view/<?php echo $this -> logged_user['id']; ?>">
                                        <?php echo $this -> logged_user['username']; ?>
                                    </a>
                                </li>
                                <li>
                                    <a id="logout-btn" href="<?php echo DX_URL ?>login/logout">Logout</a>
                                </li>
                            <?php else: ?>
                                <li>
                                    <a href="<?php echo DX_URL ?>login/">Login</a>
                                </li>
                                <li>
                                    <a href="<?php echo DX_URL ?>register/">Register</a>
                                </li>
                            <?php endif; ?>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>
        </header>