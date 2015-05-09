
<ul>
    <?php
    foreach ($this -> posts as $post) : ?>
        <li>
            <?php echo "Post Id: " . htmlspecialchars($post['Id']) . ' - ' . htmlspecialchars($post['Title']); ?>
            <form method="post">
                <label for="commenter">Name: </label>
                <input type="text" required id="commenter" name="commenter" />
                <label for="email">Email: </label>
                <input type="email" id="email" name="email" />
                <label for="commentContent">Comment: </label>
                <input type="text" required id="commentContent" name="commentContent" />
                <?php foreach ($comments[$post['Id']] as $comment) : ?>
                <p>
                    <?php echo htmlspecialchars($comment['Content']);?>
                </p>
                <?php endforeach; ?>
                <input type="hidden" name="commentPostId" value="<?php echo intval($post['Id']); ?>" />
                <input type="submit" value="Comment" />
            </form>
        </li>
    <?php endforeach; ?>
</ul>

<br />
<br />
<br />
<br />
<?php include_once '/views/elements/filterbar.php'; ?>