<?php echo 'hello from filterbar'; ?>
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