<div id="filterbar">
    <form method="post">
        <label for="pageNumber">Page Number: </label>
        <input type="pageNumber" id="pageNumber" name="pageNumber" value="<?php echo addslashes($pageNumber); ?>" />
        <label for="pageSize">Page Size: </label>
        <input type="pageSize" id="pageSize" name="pageSize" value="<?php echo addslashes($pageSize); ?>" />
        <input type="submit" value="Filter" />
    </form>
</div>