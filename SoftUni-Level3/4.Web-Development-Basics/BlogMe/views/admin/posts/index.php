<div class="container">

    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-4">
            <?php if( ! empty($this -> deletion_message) ): ?>
                <div class="alert alert-danger error" role="alert"><?php echo $this -> deletion_message ?></div>
                <?php $this -> deletion_message = ''; ?>
            <?php endif; ?>
        </div>
    </div>

    <?php foreach ($this -> posts as $post) : ?>
        <div class="row">

            <div class="col-lg-2"></div>
            <!-- Blog Post Content Column -->
            <div class="col-lg-8">

                <!-- Blog Post -->

                <!-- Title -->
                <h1><?php echo htmlspecialchars($post['Title']); ?></h1>

                <!-- Author -->
                <p class="lead">
                    by <a href="<?php echo DX_URL ?>admin/users/view/<?php
                    $author = $this -> authors[$post['Id']][0];
                    echo htmlspecialchars($author['Id']); ?>"><?php
                    echo htmlspecialchars($author['Username']); ?></a>
                </p>

                <hr>

                <!-- Date/Time -->
                <p>
                    <span class="glyphicon glyphicon-time"></span>
                    Posted on <?php echo htmlspecialchars($post['Date_Published']); ?>
                </p>

                <hr>

                <p>
                    <span class="glyphicon glyphicon-tags"></span>
                    Tags:
                    <?php
                    foreach( $this -> tags[$post['Id']] as $tag_array ):  ?>
                        <a href="<?php
                        echo DX_URL ?>admin/posts/search_by_tag/<?php
                        echo htmlspecialchars( $tag_array['Id'])?>"><?php
                        echo htmlspecialchars( $tag_array['Name'])?></a>
                    <?php endforeach; ?>
                </p>

                <hr>

                <!-- Preview Image -->
                <!--                <img class="img-responsive" src="http://placehold.it/900x300" alt="">-->
                <!---->
                <!--                <hr>-->

                <!-- Post Content -->
                <div class="well">
                    <p><?php echo htmlspecialchars($post['Content']); ?></p>
                </div>

                <hr>
                <a class="btn btn-default" href="<?php echo DX_URL ?>admin/posts/edit/<?php echo $post['Id'] ?>">
                    Edit Post
                </a>
                <a class="btn btn-default" href="<?php echo DX_URL ?>admin/posts/delete/<?php echo $post['Id'] ?>">
                    Delete Post
                </a>

                <hr>

                <!-- Blog Comments -->

                <!-- Comments Form -->
                <div class="well">
                    <h4>Leave a Comment:</h4>
                    <form method="post" role="form">
                        <div class="form-group">
                            <label for="commenter">Name: </label>
                            <input type="text" required id="commenter" name="commenter" />
                            <label for="email">Email: </label>
                            <input type="email" id="email" name="email" />
                            <textarea required="required" id="commentContent" name="commentContent" class="form-control"
                                      rows="3" placeholder="Your comment..."></textarea>
                            <input type="hidden" name="commentPostId" value="<?php echo intval($post['Id']); ?>" />
                        </div>
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </form>
                </div>

                <hr>

                <!-- Posted Comments -->

                <?php foreach ($this -> comments[$post['Id']] as $comment) : ?>
                    <!-- Comment -->
                    <div class="media">
                        <a class="pull-left" href="#">
                            <img class="media-object" src="http://placehold.it/64x64" alt="">
                        </a>
                        <div class="media-body">
                            <h5 class="media-heading">
                                Comment by:
                                <?php
                                if( ! empty( $comment['CommenterEmail'] ) ): ?>
                                    <a href="<?php echo 'mailto:' . htmlspecialchars($comment['CommenterEmail']) ?>"
                                       target="_blank">
                                        <?php echo htmlspecialchars($comment['CommenterName']);?>
                                    </a>
                                <?php else:
                                    echo htmlspecialchars($comment['CommenterName']);
                                endif; ?>
                                <small>
                                    <span class="glyphicon glyphicon-time"></span>
                                    <?php echo htmlspecialchars($comment['Date_Commented']);?>
                                </small>
                            </h5>
                            <?php echo htmlspecialchars($comment['Content']);?>
                        </div>
                    </div>
                <?php endforeach; ?>
                <hr>
            </div>
        </div>
    <?php endforeach; ?>
    <!-- /.row -->

    <hr>

    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <div class="panel panel-default" id="filterbar">
                <div class="panel-heading">Paging:</div>
                <div class="panel-body">
                    <form method="post">
                        <label for="pageNumber">Page Number: </label>
                        <input type="pageNumber" id="pageNumber" name="pageNumber"
                               value="<?php echo htmlspecialchars($pageNumber); ?>" />
                        <label for="pageSize">Page Size: </label>
                        <input type="pageSize" id="pageSize" name="pageSize"
                               value="<?php echo htmlspecialchars($pageSize); ?>" />
                        <?php echo 'Total Posts: ' . htmlspecialchars($totalCount); ?>
                        <input type="submit" id="filter" value="Filter" />
                    </form>
                </div>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>
    <?php include_once '/views/elements/filterbar.php'; ?>