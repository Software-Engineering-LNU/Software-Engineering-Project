#!/usr/bin/env bash
LC_ALL=C

local_branch="$(git rev-parse --abbrev-ref HEAD)"

valid_branch_regex="^(task|master|develop|qa|tb|bug|story)[a-z0-9._-]{2,10}$"

message="This branch violates the branch naming rules. Please rename your branch."

if [[ ! $local_branch =~ $valid_branch_regex ]]
then
    echo "$message"
    exit 1
fi

exit 0