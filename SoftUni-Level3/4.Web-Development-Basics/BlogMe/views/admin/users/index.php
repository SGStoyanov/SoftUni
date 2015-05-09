<!-- Page Content -->
<div class="container">
    <?php foreach ($users as $user) : ?>
        <div class="row">
            <div class="col-lg-2"></div>

            <!-- Blog Post Content Column -->
            <div class="col-lg-8">
                <div class="well">
                    <p>Id: <?php echo htmlspecialchars($user['Id']); ?></p>
                    <p>Username: <?php echo htmlspecialchars($user['Username']); ?></p>
                    <p>Full Name: <?php echo htmlspecialchars($user['FullName']); ?></p>
                    <p>Email: <?php echo htmlspecialchars($user['Email']); ?></p>
                </div>
            </div>

            <div class="col-md-4"></div>
        </div>
    <?php endforeach; ?>
    <!-- /.row -->

    <hr>